import { MessageInput } from './MessageInput'
import styles from '@/components/chatbot/styles/chatWindow.module.css'
import { MessageList } from '@/components/chatbot/MessageList.tsx'
import { ChatList } from '@/components/chatbot/ChatList.tsx'
import type { Message } from '@/components/chatbot/types/message.type.ts'
import type { BaseChat } from '@/components/chatbot/types/chat.type.ts'

type ChatWindowPropType = {
    chats: BaseChat[]
    messages: Message[]
}

export const ChatWindow = ({ messages, chats }: ChatWindowPropType) => {
    return (
        <section className={styles.chatWindowContainer}>
            <MessageList messages={messages} />
            <MessageInput />
            <ChatList chats={chats} />
        </section>
    )
}
