import React, { useState } from 'react';
import { Container, Form, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function IndexPage() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();

    if (!username || !password) {
      alert('Vul gebruikersnaam en wachtwoord in');
      return;
    }

    try {
      // Stap 4
      //fetch de token van de IdentityServer
      if (!res.ok) {
        alert('Verkeerde naam of wachtwoord');
        return;
      }else if (res.ok) {
              //localstorage de token opslaan

              navigate('/home');
      }
    } catch (err) {
      console.error('Login fout:', err);
      alert('Inloggen mislukt. Probeer het opnieuw.');
    }
  };

  return (
    <Container className="d-flex flex-column align-items-center justify-content-center mt-5">
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
