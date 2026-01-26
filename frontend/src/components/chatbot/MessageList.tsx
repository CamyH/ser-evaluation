import type { Message as MessageType } from '@/components/chatbot/types/message.type.ts'
import { Message } from '@/components/chatbot/Message.tsx'
import { List } from '@/components/chatbot/List.tsx'

type MessageListPropType = {
    messages: MessageType[]
}

export const MessageList = ({ messages }: MessageListPropType) => {
    if (!messages.length) {
        return <Message content={'No messages to display. Start a new chat'} />
    }

    return (
        <List
            items={messages}
            renderItem={(message, index: number) => (
                <Message
                    content={message.content}
                    key={`${message.content}-${index}`}
                />
            )}
        />
    )
}
