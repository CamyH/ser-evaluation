from typing import cast
from numpy import floating
from numpy._typing import NDArray
from transformers import Wav2Vec2ForSequenceClassification

import models.sequence_classification as sequence_classification
import models.wav2vec as wav2vec


def process_audio(model_id: str, audio: NDArray[floating]):
    """ Service to process audio dependant on given model

    :param model_id: Model ID to use
    :param audio: Audio to process
    """
    if model_id == 'prithiv':
        feature_extractor, model = sequence_classification.load_model(model_id)
        processed_audio = sequence_classification.process_audio(audio, feature_extractor)
        prediction = sequence_classification.predict(model, processed_audio)

        return prediction

    if model_id == 'ehcalabres':
        feature_extractor, model = wav2vec.load_model(model_id)
        model = cast(Wav2Vec2ForSequenceClassification, model)
        features = wav2vec.extract_features(audio, feature_extractor)
        prediction = wav2vec.predict(model, features)

        return prediction


