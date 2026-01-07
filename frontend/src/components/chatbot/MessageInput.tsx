import styles from '@/components/chatbot/styles/messageInput.module.css'
import {InputGroup, InputGroupAddon, InputGroupButton, InputGroupInput} from "@/components/ui/input-group.tsx";
import {useState} from "react";
import {SendHorizontal} from "lucide-react";

export const MessageInput = () => {
    const [isSent, setIsSent] = useState<boolean>(false);
    return (
        <section className={styles.inputContainer}>
            <InputGroup>
                <InputGroupInput type='text' placeholder='Send a message...'/>
                <InputGroupAddon align='inline-end'>
                    <InputGroupButton
                        aria-label='Submit'
                        type='submit'
                        size='icon-xs'
                        onClick={() => setIsSent(!isSent)}>{
                        <SendHorizontal type='submit'/>
                    }
                    </InputGroupButton>
                </InputGroupAddon>
            </InputGroup>
        </section>
    );
};