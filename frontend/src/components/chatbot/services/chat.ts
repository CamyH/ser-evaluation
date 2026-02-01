import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import type {
    AudioDto,
    ChatDto,
    ChatListDto,
} from '@/components/chatbot/types/chat.type.ts'

export const chatApi = createApi({
    reducerPath: 'chatApi',
    baseQuery: fetchBaseQuery({ baseUrl: import.meta.env.BASE_URL }),
    endpoints: (builder) => ({
        sendAudio: builder.mutation<void, AudioDto>({
            query: ({ file }: AudioDto) => ({
                url: '/audio',
                method: 'POST',
                body: file,
                headers: { 'Content-Type': 'audio/wav' },
            }),
        }),
        sendChatData: builder.mutation<string, ChatDto>({
            query: ({ chatId, chatName }: ChatDto) => ({
                url: `/chat/${chatId}`,
                method: 'POST',
                body: chatName,
            }),
        }),
        getChatList: builder.query<ChatListDto, void>({
            query: () => ({
                url: '/chats',
                method: 'GET',
            }),
        }),
    }),
})

export const {
    useSendAudioMutation,
    useSendChatDataMutation,
    useGetChatListQuery,
} = chatApi
