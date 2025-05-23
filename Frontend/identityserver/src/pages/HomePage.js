import React, { useEffect, useState } from 'react';
import { Container, Navbar, Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function HomePage() {
  const [studentNames, setStudentNames] = useState([]);
  const [lessons, setLessons] = useState([]);
  const [grades, setGrades] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    // Fetch studenten
    fetch('https://localhost:7285/school/students')
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
    fetch('https://localhost:7285/school/lessons')
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
    fetch('https://localhost:7285/school/grades')
      .then((res) => {
        if (!res.ok) throw new Error('Unauthorized or fetch error');
        return res.json();
      })
      .then((data) => setGrades(data))
      .catch((err) => {
        console.error(err);
        setGrades([]);
      });
  }, []);

  return (
    <>
      {/* HEADER */}
      <Navbar bg="primary" variant="dark" className="px-3">
        <Navbar.Brand href="/">Workshop</Navbar.Brand>
        <div className="mx-auto text-white">naam</div>
        <Button variant="outline-light" onClick={() => navigate('/')}>
          Uitloggen
        </Button>
      </Navbar>

      {/* CONTENT */}
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
            <h2 className="text-center mt-4 mb-3">Cijfers</h2>
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
      </Container>
    </>
  );
}

export default HomePage;
