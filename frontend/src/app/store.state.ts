import { chatApi } from '@/components/chatbot/services/chat.ts'
import { configureStore, type Store } from '@reduxjs/toolkit'

export const store: Store = configureStore({
    reducer: {
        [chatApi.reducerPath]: chatApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(chatApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = ReturnType<typeof store.dispatch>
