import React from 'react';
import { ContainerHeader, Links, LinkText } from './style';

const Header: React.FC = () => {
  return (
    <ContainerHeader data-testid="container-header">
      <h1>SMGBit Transportes</h1>
      <Links>
        <LinkText to={'/'}>Upload</LinkText>
        <LinkText to={'/travels'}>Viagens</LinkText>
      </Links>
    </ContainerHeader>
  );
};

export default Header;
