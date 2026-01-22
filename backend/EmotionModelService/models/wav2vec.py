from typing import Dict, Callable
from numpy import ndarray
from transformers import PreTrainedModel
from logging import getLogger
from typing import Tuple
from torch import Tensor, no_grad, softmax, argmax
from librosa import load
from transformers import AutoFeatureExtractor, AutoModelForAudioClassification

logger = logging.getLogger(__name__)

def load_model(model_id: str) -> Tuple[AutoFeatureExtractor, AutoModelForAudioClassification]:
    """Load the Model & Feature Extractor
    Model currently used: "ehcalabres/wav2vec2-lg-xlsr-en-speech-emotion-recognition"
    https://huggingface.co/ehcalabres/wav2vec2-lg-xlsr-en-speech-emotion-recognition?utm_source=chatgpt.com

    :param model_id: The ID of the model to load
    :return: The initialised feature extractor and model
    """
    logger.info("ModelID: " + model_id)
    return AutoFeatureExtractor.from_pretrained(model_id), AutoModelForAudioClassification.from_pretrained(model_id)

def load_audio_locally(audio_path: str) -> tuple[ndarray, int | float]:
    """Load audio from a local file

    Only for local DEV
    :param audio_path: The path to the audio file
    :return: The loaded audio file
    """
    logger.info("Loading " + audio_path)
    return load(audio_path, sr=16000, mono=True)

def extract_features(audio: ndarray[float], feature_extractor: Callable[..., dict[str, Tensor]]) -> dict[str, Tensor]:
    """ Extract features from audio

    Sample Rate must be 16000 and audio must be mono (single channel)
    :param audio: The audio to use
    :param feature_extractor: The feature extractor to use
    :return: The extracted features
    """
    return feature_extractor(
        audio,
        sampling_rate=16000,
        return_tensors="pt",
        padding=True
)

def predict(model: PreTrainedModel, features: Dict[str, Tensor]) -> str:
    """ Run inference on a set of audio features

    :param model: The model to run inference on
    :param features: The features to run inference on
    :return: The prediction
    """
    with no_grad():
        outputs = model(**features)
        logits = outputs.logits
        probs = softmax(logits, dim=-1)
        pred_index = argmax(probs, dim=-1).item()

        pred_label = model.config.id2label[pred_index]
        logger.info(pred_label)

        return pred_label
