package main

import (
	"DialogueService/internal/websockets"
	"log"
	"net/http"
)

func main() {
	http.HandleFunc("/ws", websockets.Handler)

	log.SetPrefix("[INFO] ")
	log.Println("Websocket Started on :8080")
	err := http.ListenAndServe(":8080", nil)
	if err != nil {
		log.Fatal(err)
	}
}
