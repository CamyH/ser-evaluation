import {Item, ItemContent} from "@/components/ui/item.tsx";
import type {BaseMessage} from "@/components/chatbot/types/message.type.ts";

type MessagePropType = BaseMessage

export const Message = ({content}: MessagePropType) => {
    return (
        <Item variant='outline' size='sm'>
            <ItemContent>{content}</ItemContent>
        </Item>
    );
};