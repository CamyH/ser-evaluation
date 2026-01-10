import { Item, ItemContent } from '@/components/ui/item.tsx'
import type { BaseMessage } from '@/components/chatbot/types/message.type.ts'
import styles from '@/components/chatbot/styles/message.module.css'

type MessagePropType = BaseMessage

export const Message = ({ content }: MessagePropType) => {
    return (
        <Item variant="outline" size="sm" className={styles.message}>
            <ItemContent>{content}</ItemContent>
        </Item>
    )
}
