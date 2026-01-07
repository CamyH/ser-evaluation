import {Item, ItemContent} from "@/components/ui/item.tsx";

type MessagePropType = {
    content: string
}

export const Message = ({content}: MessagePropType) => {
    return (
        <Item variant='outline' size='sm'>
            <ItemContent>{content}</ItemContent>
        </Item>
    );
};