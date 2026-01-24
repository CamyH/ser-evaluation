from logging import getLogger
from typing import Tuple
from numpy import floating
from numpy._typing import NDArray
from torch import no_grad, nn
from transformers import Wav2Vec2ForSequenceClassification, Wav2Vec2FeatureExtractor, PreTrainedModel, BatchFeature

logger = getLogger(__name__)

id2label = {
    "0": "Anger",
    "1": "Calm",
    "2": "Disgust",
    "3": "Fear",
    "4": "Happy",
    "5": "Neutral",
    "6": "Sad",
    "7": "Surprised"
}

def load_model(model_id: str) -> Tuple[Wav2Vec2FeatureExtractor, Wav2Vec2ForSequenceClassification]:
    """Load the Model & Feature Extractor
    Model currently used: "prithivMLmods/Speech-Emotion-Classification"
    https://huggingface.co/prithivMLmods/Speech-Emotion-Classification?utm_source=chatgpt.com

    :param model_id: The ID of the model to load
    :return: The initialised feature extractor and model
    """
    logger.info("ModelID: " + model_id)
    return Wav2Vec2FeatureExtractor.from_pretrained(model_id), Wav2Vec2ForSequenceClassification.from_pretrained(model_id)

def process_audio(audio: NDArray[floating], processor: Wav2Vec2FeatureExtractor) -> BatchFeature:
    """ Process Audio

    Sample Rate must be 16000 and audio must be mono (single channel)
    :param audio: The audio to use
    :param processor: The feature extractor to use
    :return: The extracted features
    """
    return processor(
        audio,
        sampling_rate=16000,
        return_tensors="pt",
        padding=True
)

def predict(model: PreTrainedModel, inputs: BatchFeature) -> dict:
    """ Run inference on a set of audio features

    :param model: The model to run inference on
    :param inputs: The features to run inference on
    :return: The prediction
    """
    with no_grad():
        outputs = model(**inputs)
        logits = outputs.logits
        probabilities = nn.functional.softmax(logits, dim=1).squeeze().tolist()

        pred_label = {
            id2label[str(i)]: round(probabilities[i], 3) for i in range(len(probabilities))
        }
        logger.info(pred_label)

        return pred_label
