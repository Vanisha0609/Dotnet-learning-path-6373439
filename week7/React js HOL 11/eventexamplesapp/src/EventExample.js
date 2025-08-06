import React, { useState } from 'react';

function EventExample() {
  const [count, setCount] = useState(0);
  const [message, setMessage] = useState('');
  const [rupees, setRupees] = useState('');
  const [euro, setEuro] = useState('');

  const increment = () => {
    setCount(prev => prev + 1);
    sayHello();
    showMessage();
  };

  const decrement = () => setCount(prev => prev - 1);

  const sayHello = () => console.log("Hello!");

  const showMessage = () => setMessage("This is a static message.");

  const sayWelcome = (msg) => {
    alert(msg);
  };

  const handleSyntheticClick = (e) => {
    alert("I was clicked");
    console.log("Synthetic event object:", e);
  };

  const handleSubmit = () => {
    const converted = (parseFloat(rupees) / 90).toFixed(2); // Assume 1 Euro = 90 INR
    setEuro(converted);
  };

  return (
    <div style={{ padding: "20px" }}>

      <h2>Counter: {count}</h2>
      <button onClick={increment}>Increment</button>
      <button onClick={decrement}>Decrement</button>
      <p>{message}</p>

      <hr />

      <button onClick={() => sayWelcome("Welcome!")}>Say Welcome</button>

      <hr />

      <button onClick={handleSyntheticClick}>Click Me (Synthetic Event)</button>

      <hr />

      <div>
        <h2>Currency Converter (INR → EUR)</h2>
        <input 
          type="number"
          placeholder="Enter amount in INR"
          value={rupees}
          onChange={(e) => setRupees(e.target.value)}
        />
        <button onClick={handleSubmit}>Convert</button>
        {euro && <p>€ {euro}</p>}
      </div>
    </div>
  );
}

export default EventExample;
