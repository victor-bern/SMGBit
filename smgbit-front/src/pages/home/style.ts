import ClipLoader from 'react-spinners/ClipLoader';
import styled from 'styled-components';

export const Container = styled.div`
  display: flex;
  height: 100%;
  width: 100%;
  flex-direction: column;
`;

export const UploadContainer = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  width: 100%;
  flex-direction: column;
`;

export const UploadText = styled.label`
  font-size: 32px;
  font-family: 'Roboto', sans-serif;
  font-weight: bold;
  margin-bottom: 16px;
`;

export const UploadInput = styled.input``;

export const Error = styled.p`
  color: red;
  font-family: 'Roboto', sans-serif;
  font-weight: bold;
  font-size: 26;
`;

type ButtonProps = {
  fileSelected: boolean;
};

export const SubmitButton = styled.button<ButtonProps>`
  margin-top: 26px;
  color: white;
  border: none;
  height: 42px;
  width: 128px;
  pointer-events: ${(props) => (props.fileSelected ? 'none' : null)};
  border-radius: 6px;
  font-family: 'Roboto', sans-serif;
  font-size: 16px;
  background-color: ${(props) => (props.fileSelected ? 'grey' : '#2196f3')};
  margin-bottom: 26px;
`;

export const Load = styled(ClipLoader)`
  margin-top: 12px;
`;
