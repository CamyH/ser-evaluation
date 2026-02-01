import styles from '@/components/chatbot/styles/messageInput.module.css'
import {
    InputGroup,
    InputGroupAddon,
    InputGroupButton,
    InputGroupInput,
} from '@/components/ui/input-group.tsx'
import { type ChangeEvent, useState } from 'react'
import { SendHorizontal } from 'lucide-react'

type MessageInputPropType = {
    onChange: (userUpload: ChangeEvent<HTMLInputElement>) => void
}

export const MessageInput = ({ onChange }: MessageInputPropType) => {
    const [isSent, setIsSent] = useState<boolean>(false)
    return (
        <form className={styles.inputContainer}>
            <InputGroup>
                <InputGroupInput
                    type="file"
                    placeholder="Send a message..."
                    className={styles.input}
                    onChange={onChange}
                />
                <InputGroupAddon align="inline-end">
                    <InputGroupButton
                        aria-label="Submit"
                        type="submit"
                        size="icon-xs"
                        onClick={() => setIsSent(!isSent)}
                    >
                        {<SendHorizontal type="submit" />}
                    </InputGroupButton>
                </InputGroupAddon>
            </InputGroup>
        </form>
    )
}
