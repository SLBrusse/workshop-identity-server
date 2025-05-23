import React, { useState } from 'react';
import { Container, Form, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function IndexPage() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = (e) => {
    e.preventDefault();
    //Hier fetch naar de login api
    if (username && password) {
      navigate('/home');
    } else {
      alert('Vul gebruikersnaam en wachtwoord in');
    }
  };

  return (
    <Container className="d-flex flex-column align-items-center justify-content-center mt-5">
      <img
        src="/images/eend.jpg"
        alt="Eend"
        className="img-fluid mb-4"
        style={{ maxHeight: '300px' }}
      />
      <h1 className="mb-4">Hallo bezoeker</h1>
      <Form style={{ maxWidth: '400px', width: '100%' }} onSubmit={handleLogin}>
        <Form.Group className="mb-3" controlId="formUsername">
          <Form.Label>Gebruikersnaam</Form.Label>
          <Form.Control
            type="text"
            placeholder="Voer je naam in"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
          />
        </Form.Group>

        <Form.Group className="mb-3" controlId="formPassword">
          <Form.Label>Wachtwoord</Form.Label>
          <Form.Control
            type="password"
            placeholder="Wachtwoord"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </Form.Group>

        <div className="text-center">
          <Button variant="primary" type="submit">
            Inloggen
          </Button>
        </div>
      </Form>
    </Container>
  );
}

export default IndexPage;
