import type { ReactNode } from 'react'
import styles from '@/components/chatbot/styles/chatPageLayout.module.css'

type ChatPageLayoutProps = {
    children: ReactNode
}

export const ChatPageLayout = ({ children }: ChatPageLayoutProps) => {
    return <main className={styles.mainContainer}>{children}</main>
}
