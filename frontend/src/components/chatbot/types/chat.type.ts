import type { Message } from '@/components/chatbot/types/message.type.ts'

export type BaseChat = {
    chatId: string
    chatName: string
}

export type ChatState = {
    // First string is chatId
    messages: Record<string, Message[]>
}

export type ChatDto = {
    file: File[]
}
