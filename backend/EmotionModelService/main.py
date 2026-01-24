from fastapi import FastAPI, File
from librosa import load
from io import BytesIO
from services.emotion_classification import process_audio

app = FastAPI()

@app.get("/api/v1/")
async def health():
    return {"Healthy"}

@app.post("/api/v1/audio/")
async def audio(model: str, normalized_audio: bytes = File(...)) -> str:
    loaded_audio, _ = load(BytesIO(normalized_audio), sr=16000, mono=True)

    prediction = process_audio(model, loaded_audio)

    return prediction
