import React from 'react';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Header from './components/Header';
import GlobalStyle from './globalStyles';
import Home from './pages/home';
import Travels from './pages/travels';
console.log(process.env);
const App: React.FC = () => {
  return (
    <BrowserRouter>
      <GlobalStyle />
      <Header />
      <Routes>
        <Route path='/' element={<Home />} />
        <Route path='/travels' element={<Travels />} />
      </Routes>
    </BrowserRouter>
  );
};

export default App;
