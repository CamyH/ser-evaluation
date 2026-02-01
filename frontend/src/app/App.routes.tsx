import { BrowserRouter, Route, Routes } from 'react-router'
import { ChatRoute } from '@/app/routes/Chat.route.tsx'

export const AppRoutes = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/chat" element={<ChatRoute />} />
            </Routes>
        </BrowserRouter>
    )
}
