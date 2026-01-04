import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './main.css'
import {BrowserRouter, Routes} from "react-router";

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <BrowserRouter>
      <Routes>
      </Routes>
    </BrowserRouter>
  </StrictMode>,
)
