import { Item, ItemContent } from '@/components/ui/item.tsx'
import styles from '@/components/chatbot/styles/chat.module.css'

type ChatPropType = {
    chatName: string
}

export const Chat = ({ chatName }: ChatPropType) => {
    return (
        <span>
            <Item size="sm" className={styles.chat}>
                <ItemContent>{chatName}</ItemContent>
            </Item>
        </span>
    )
}
