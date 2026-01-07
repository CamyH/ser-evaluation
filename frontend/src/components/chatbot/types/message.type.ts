export type BaseMessage = {
    content: string
}

export type Message = BaseMessage & {
    userId: string
}