import React from 'react';

const T20Players = ['Virat', 'Rohit', 'Pant', 'Hardik', 'Gill'];
const RanjiTrophyPlayers = ['Rahane', 'Pujara', 'Saha', 'Karun Nair'];

const IndianPlayers = () => {
  const allPlayers = [...T20Players, ...RanjiTrophyPlayers];

  const oddPlayers = allPlayers.filter((_, index) => index % 2 !== 0);
  const evenPlayers = allPlayers.filter((_, index) => index % 2 === 0);

  return (
    <div>
      <h2>Odd Team Players</h2>
      <ul>
        {oddPlayers.map((name, index) => <li key={index}>{name}</li>)}
      </ul>

      <h2>Even Team Players</h2>
      <ul>
        {evenPlayers.map((name, index) => <li key={index}>{name}</li>)}
      </ul>

      <h2>All Merged Players</h2>
      <ul>
        {allPlayers.map((name, index) => <li key={index}>{name}</li>)}
      </ul>
    </div>
  );
};

export default IndianPlayers;
