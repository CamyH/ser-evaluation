import type {Message as MessageType} from "@/components/chatbot/types/message.type.ts";
import {Message} from "@/components/chatbot/Message.tsx";
import styles from '@/components/chatbot/styles/messageList.module.css'

type MessageListPropType = {
    messages: MessageType[],
}

export const MessageList = ({messages}: MessageListPropType) => {
    return (
        <section className={styles.messageContainer}>
            {messages.map((message, index) => {
                return <Message content={message.content} key={index}/>
            })}
        </section>
    );
};