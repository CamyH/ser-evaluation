import { MessageInput } from './MessageInput'
import styles from '@/components/chatbot/styles/chatWindow.module.css'
import { MessageList } from '@/components/chatbot/MessageList.tsx'

export const ChatWindow = () => {
    return (
        <section className={styles.chatWindowContainer}>
            <MessageList messages={[]} />
            <MessageInput />
        </section>
    )
}
