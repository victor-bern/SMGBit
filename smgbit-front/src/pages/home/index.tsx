import { useState } from 'react';
import { FiCheckCircle } from 'react-icons/fi';
import api from '../../config/api';
import {
  Container,
  Error,
  Load,
  SubmitButton,
  UploadContainer,
  UploadInput,
  UploadText,
} from './style';

const Home: React.FC = () => {
  const [error, setError] = useState('');
  const [file, setFile] = useState<File | null>();
  const [isProcessing, setIsProcessing] = useState(false);
  const [isCompleted, setIsCompleted] = useState(false);

  const handleImageUpload = (event: React.ChangeEvent<HTMLInputElement>) => {
    setFile(null);
    setIsProcessing(false);
    setIsCompleted(false);
    setTimeout(() => {
      setError('');
    }, 7000);
    if (!event.target.files) return;
    var allowedExtensions = ['xlsx', 'xls'];
    var file = event.target.files[0];
    var extension = file.name.split('.')[1];
    if (!allowedExtensions.includes(extension)) {
      setError('Apenas é permitido formato xlsx e xls');
      return;
    }
    setFile(file);
  };

  const handleButtonClick = async () => {
    setIsProcessing(true);
    try {
      const formData: any = new FormData();
      formData.append('file', file);

      var response = await api.post('/travels/process_file', formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });
      if (response.status === 200) setIsCompleted(true);
    } catch (e) {
      setIsProcessing(false);
      console.log(e);
    }
  };

  return (
    <Container>
      <UploadContainer>
        <UploadText htmlFor='file'>
          Faça o upload do arquivo xls ou xlsx
        </UploadText>
        <UploadInput id='file' type={'file'} onChange={handleImageUpload} />
        <SubmitButton
          fileSelected={file ? false : true}
          onClick={handleButtonClick}
        >
          Enviar
        </SubmitButton>
        {error ? <Error>{error}</Error> : null}
        {isProcessing ? (
          <>
            {isCompleted ? (
              <FiCheckCircle size={48} color={'green'} />
            ) : (
              <Load />
            )}
          </>
        ) : null}
      </UploadContainer>
    </Container>
  );
};

export default Home;
