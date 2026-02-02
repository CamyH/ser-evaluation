package websockets

import (
	"log"
	"net/http"
	"net/http/httptest"
	"testing"

	"github.com/gorilla/websocket"
)

// echoHandler upgrades an HTTP request to a WebSocket and echoes back a single message
func echoHandler(writer http.ResponseWriter, request *http.Request) {
	upgrader := websocket.Upgrader{
		CheckOrigin: func(r *http.Request) bool { return true },
	}

	conn, err := upgrader.Upgrade(writer, request, nil)
	if err != nil {
		log.Println("failed to upgrade connection:", err)
		return
	}
	defer func(conn *websocket.Conn) {
		err := conn.Close()
		if err != nil {
			log.Println("failed to close connection:", err)
		}
	}(conn)

	_, msg, err := conn.ReadMessage()
	if err != nil {
		log.Println("failed to read message:", err)
		return
	}

	if err := conn.WriteMessage(websocket.TextMessage, msg); err != nil {
		log.Println("failed to write message:", err)
		return
	}
}

// TestHandler verifies that the WebSocket handler successfully echoes a sent message
func TestHandler(t *testing.T) {
	server := httptest.NewServer(http.HandlerFunc(echoHandler))
	defer server.Close()

	url := "ws" + server.URL[len("http"):]

	ws, _, err := websocket.DefaultDialer.Dial(url, nil)
	if err != nil {
		t.Fatalf("failed to connect websocket: %v", err)
	}
	defer func(ws *websocket.Conn) {
		err := ws.Close()
		if err != nil {
			log.Println("failed to close connection:", err)
		}
	}(ws)

	message := "test message"

	err = ws.WriteMessage(websocket.TextMessage, []byte(message))
	if err != nil {
		t.Fatalf("failed to write message: %v", err)
	}

	_, received, err := ws.ReadMessage()
	if err != nil {
		t.Fatalf("failed to read message: %v", err)
	}

	if string(received) != message {
		t.Fatalf("expected '%s', got '%s'", message, string(received))
	}
}
