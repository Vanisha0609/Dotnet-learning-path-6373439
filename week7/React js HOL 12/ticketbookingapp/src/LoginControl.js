import { useState } from 'react';
import Guest from './Guest';
import User from './User';

function LoginControl() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLoginClick = () => setIsLoggedIn(true);
  const handleLogoutClick = () => setIsLoggedIn(false);

  let button;
  let content;

  if (isLoggedIn) {
    button = <button onClick={handleLogoutClick}>Logout</button>;
    content = <User />;
  } else {
    button = <button onClick={handleLoginClick}>Login</button>;
    content = <Guest />;
  }

  return (
    <div>
      {button}
      {content}
    </div>
  );
}

export default LoginControl;
