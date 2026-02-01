import { ChatWindow } from '@/components/chatbot/ChatWindow.tsx'
import { ChatPageLayout } from '@/components/chatbot/layouts/ChatPageLayout.tsx'
import { ChatList } from '@/components/chatbot/ChatList.tsx'

export const ChatRoute = () => {
    return (
        <ChatPageLayout>
            <ChatList chats={[]} />
            <ChatWindow chats={[]} messages={[]} />
        </ChatPageLayout>
    )
}
