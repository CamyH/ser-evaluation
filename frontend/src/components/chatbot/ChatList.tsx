import type { BaseChat } from '@/components/chatbot/types/chat.type.ts'
import { Chat } from '@/components/chatbot/Chat.tsx'
import { List } from '@/components/chatbot/List.tsx'
import styles from '@/components/chatbot/styles/chat.module.css'

type ChatListPropType = {
    chats: BaseChat[]
}

export const ChatList = ({ chats }: ChatListPropType) => {
    if (!chats.length) {
        return <p className={styles.chatList}>No chats found.</p>
    }

    return (
        <List
            items={chats}
            renderItem={(chat) => (
                <Chat chatName={chat.chatName} key={chat.chatId} />
            )}
        />
    )
}
