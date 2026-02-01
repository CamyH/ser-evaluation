import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import type { ChatDto } from '@/components/chatbot/types/chat.type.ts'

export const chatApi = createApi({
    reducerPath: 'chatApi',
    baseQuery: fetchBaseQuery({ baseUrl: import.meta.env.BASE_URL }),
    endpoints: (builder) => ({
        sendAudio: builder.mutation<void, ChatDto>({
            query: ({ file }: ChatDto) => ({
                url: '/audio',
                method: 'POST',
                body: file,
            }),
        }),
    }),
})

export const { useSendAudioMutation } = chatApi
