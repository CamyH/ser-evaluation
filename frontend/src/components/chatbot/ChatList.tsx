import type { BaseChat } from '@/components/chatbot/types/chat.type.ts'
import { Chat } from '@/components/chatbot/Chat.tsx'
import { List } from '@/components/chatbot/List.tsx'

type ChatListPropType = {
    chats: BaseChat[]
}

export const ChatList = ({ chats }: ChatListPropType) => {
    return (
        <List
            items={chats}
            renderItem={(chat) => (
                <Chat chatName={chat.chatName} key={chat.chatId} />
            )}
        />
    )
}
