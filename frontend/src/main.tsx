import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './main.css'
import { AppRoutes } from '@/app/App.routes.tsx'

createRoot(document.getElementById('root')!).render(
    <StrictMode>
        <AppRoutes />
    </StrictMode>
)
