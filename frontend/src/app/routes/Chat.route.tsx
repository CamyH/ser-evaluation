import { ChatWindow } from '@/components/chatbot/ChatWindow.tsx'
import { ChatPageLayout } from '@/components/chatbot/layouts/ChatPageLayout.tsx'
import { ChatList } from '@/components/chatbot/ChatList.tsx'

export const ChatRoute = () => {
    return (
        <ChatPageLayout>
            <ChatList
                chats={[
                    { chatId: '1', chatName: 'test' },
                    { chatId: '2', chatName: 'test2' },
                ]}
            />
            <ChatWindow chats={[]} messages={[]} />
        </ChatPageLayout>
    )
}
