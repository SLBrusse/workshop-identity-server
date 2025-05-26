import React, { useEffect, useState } from 'react';
import { Container, Navbar, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function parseJwt(token) {
  try {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(
      atob(base64)
        .split('')
        .map((c) => '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2))
        .join('')
    );
    return JSON.parse(jsonPayload);
  } catch (e) {
    return null;
  }
}

function HomePage() {
  const [studentNames, setStudentNames] = useState([]);
  const [lessons, setLessons] = useState([]);
  const [grades, setGrades] = useState([]);
  const [grade, setGrade] = useState('');
  const [studentInfo, setStudentInfo] = useState([]);
  const [username, setUsername] = useState('');
  const [role, setRole] = useState('');
  const navigate = useNavigate();

  useEffect(() => {
    const token = localStorage.getItem('token');
    if (!token) {
      navigate('/');
      return;
    }

    const payload = parseJwt(token);
    if (payload) {
      setUsername(payload.name || 'Onbekend');
      setRole(payload.role || 'Geen rol');
    }

    const headers = {
      'Authorization': `Bearer ${token}`,
    };

    // Fetch studenten
    fetch('https://localhost:7285/school/students', { headers })
      .then((res) => {
        if (!res.ok) throw new Error('Unauthorized or fetch error');
        return res.json();
      })
      .then((data) => setStudentNames(data))
      .catch((err) => {
        console.error(err);
        setStudentNames([]);
      });

    // Fetch lessen
    fetch('https://localhost:7285/school/lessons', { headers })
      .then((res) => {
        if (!res.ok) throw new Error('Unauthorized or fetch error');
        return res.json();
      })
      .then((data) => setLessons(data))
      .catch((err) => {
        console.error(err);
        setLessons([]);
      });

    // Fetch cijfers
    fetch('https://localhost:7285/sensitive/grades', { headers })
      .then((res) => {
        if (!res.ok) throw new Error('Unauthorized or fetch error');
        return res.json();
      })
      .then((data) => setGrades(data))
      .catch((err) => {
        console.error(err);
        setGrades([]);
      });

    // Fetch gevoelige informatie
    fetch('https://localhost:7285/sensitive/information', { headers })
      .then((res) => {
        if (!res.ok) throw new Error('Unauthorized or fetch error');
        return res.json();
      })
      .then((data) => setStudentInfo(data))
      .catch((err) => {
        console.error(err);
        setStudentInfo([]);
      });
  }, [navigate]);

  useEffect(() => {
  if (!username) return; 

  const token = localStorage.getItem('token');
  if (!token) return;

  const headers = {
    'Authorization': `Bearer ${token}`,
  };
  
  // mijn cijfer
  fetch(`https://localhost:7285/sensitive/grade?naam=${encodeURIComponent(username)}`, { headers })
    .then((res) => {
      if (!res.ok) throw new Error('Unauthorized or fetch error');
      return res.json();
    })
    .then((data) => setGrade(data.cijfer || ''))
    .catch((err) => {
      console.error(err);
      setGrade('');
    });
}, [username]);

  return (
    <>
      <Navbar bg="primary" variant="dark" className="px-3">
        <Navbar.Brand href="/">Workshop</Navbar.Brand>
        <div className="mx-auto text-white">
          Ingelogd als: <strong>{username}</strong> ({role})
        </div>
        <Button variant="outline-light" onClick={() => navigate('/')}>
          Uitloggen
        </Button>
      </Navbar>

      <Container className="mt-5">
        {/* Studenten Namen */}
        {studentNames.length > 0 && (
          <>
            <h2 className="text-center mb-3">Studenten Namen</h2>
            <ul className="text-center list-unstyled">
              {studentNames.map((naam, idx) => (
                <li key={idx}>{naam}</li>
              ))}
            </ul>
            <hr className="my-4" style={{ width: '75%', margin: '0 auto' }} />
          </>
        )}

        {/* Lessen en Vakken */}
        {lessons.length > 0 && (
          <>
            <h2 className="text-center mt-4 mb-3">Lessen en Vakken</h2>
            <ul className="text-center list-unstyled">
              {lessons.map((les, idx) => (
                <li key={idx}>
                  {les.vak} — {les.lokaal}
                </li>
              ))}
            </ul>
            <hr className="my-4" style={{ width: '75%', margin: '0 auto' }} />
          </>
        )}

        {/* Cijfers */}
        {grades.length > 0 && (
          <>
            <h2 className="text-center mt-4 mb-3">Alle Cijfers</h2>
            <ul className="text-center list-unstyled">
              {grades.map((g, idx) => (
                <li key={idx}>
                  {g.naam}: {g.cijfer}
                </li>
              ))}
            </ul>
            <hr className="my-4" style={{ width: '75%', margin: '0 auto' }} />
          </>
        )}

        {/* Mijn Cijfer (alleen voor Leerling) */}
        {role === 'Leerling' && (
          <>
            <h2 className="text-center mt-4 mb-3">Mijn Cijfer</h2>
            {grade ? (
              <p className="text-center">{username}: {grade}</p>
            ) : (
              <p className="text-center">Geen cijfer beschikbaar.</p>
            )}
            <hr className="my-4" style={{ width: '75%', margin: '0 auto' }} />
          </>
        )}

        {/* Leerlingen Gevoelige Informatie */}
        {studentInfo.length > 0 && (
          <>
            <h2 className="text-center mt-4 mb-3">Leerlingen Gevoelige Informatie</h2>
            <ul className="text-center list-unstyled">
              {studentInfo.map((s, idx) => (
                <li key={idx}>
                  {s.naam}: {s.informatie}
                </li>
              ))}
            </ul>
            <hr className="my-4" style={{ width: '75%', margin: '0 auto' }} />
          </>
        )}
      </Container>
    </>
  );
}

export default HomePage;
