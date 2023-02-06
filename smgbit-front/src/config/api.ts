import axios from 'axios';
const host = process.env.REACT_APP_ISDOCKER
  ? 'http://localhost'
  : 'https://localhost:7027';

export default axios.create({
  baseURL: host,
});
