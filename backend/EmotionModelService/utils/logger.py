import logging

def setup_logger(logger_name, level=logging.INFO):
    """ Sets up the logger with the given name and level

    :param logger_name: The name of the logger
    :param level: The logging level
    :return: The logger object
    """
    logging.basicConfig(level=level)
    return logging.getLogger(logger_name)