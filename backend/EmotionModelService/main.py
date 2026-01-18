from fastapi import FastAPI

app = FastAPI()


@app.get("/api/v1/")
async def health():
    return {"Healthy"}

@app.post("/api/v1/audio")
async def audio():
    return None
