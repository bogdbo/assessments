import * as React from 'react';
import {Link} from 'react-router-dom';

export const Logo: React.FC = () => {
  return (
    <Link to="/">
      <img src='/images/doctorlinklogo.svg' alt={'doctor link logo'}/>
    </Link>
  )
};


