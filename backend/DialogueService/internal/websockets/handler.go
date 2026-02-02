package websockets

import (
	"log"
	"net/http"

	"github.com/gorilla/websocket"
)

var upgrader = websocket.Upgrader{
	CheckOrigin: func(r *http.Request) bool {
		return true
	},
}

func Handler(writer http.ResponseWriter, request *http.Request) {
	conn, err := upgrader.Upgrade(writer, request, nil)

	if err != nil {
		log.SetPrefix("[ERROR] ")
		log.Println("Error upgrading connection ,", err)
		return
	}

	defer func(conn *websocket.Conn) {
		err := conn.Close()
		if err != nil {
			log.SetPrefix("[ERROR] ")
			log.Fatal("Error closing connection ,", err)
		}
	}(conn)

	for {
		_, message, err := conn.ReadMessage()

		if err != nil {
			log.SetPrefix("[ERROR] ")
			log.Println("Error reading message ,", err)
			break
		}

		log.SetPrefix("[INFO] ")
		log.Println(string(message))

		if err := conn.WriteMessage(websocket.TextMessage, message); err != nil {
			log.SetPrefix("[ERROR] ")
			log.Println("Error writing message ,", err)
			break
		}
	}
}
