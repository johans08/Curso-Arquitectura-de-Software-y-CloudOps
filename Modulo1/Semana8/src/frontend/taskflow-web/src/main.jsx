import React, { useState } from 'react';
import { createRoot } from 'react-dom/client';
import './styles.css';

const API_URL = 'http://localhost:5000';

function App() {
  const [token, setToken] = useState('');
  const [tasks, setTasks] = useState([]);
  const [title, setTitle] = useState('');
  const [description, setDescription] = useState('');

  async function login() {
    const response = await fetch(`${API_URL}/auth/login`, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({ username: 'student', password: 'student123' })
    });
    const data = await response.json();
    setToken(data.accessToken);
  }

  async function loadTasks() {
    const response = await fetch(`${API_URL}/api/v1/tasks`, {
      headers: { Authorization: `Bearer ${token}` }
    });
    setTasks(await response.json());
  }

  async function createTask() {
    await fetch(`${API_URL}/api/v1/tasks`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`
      },
      body: JSON.stringify({ title, description })
    });
    setTitle('');
    setDescription('');
    await loadTasks();
  }

  return (
    <main className="container">
      <section className="hero">
        <h1>TaskFlow</h1>
        <p>Frontend moderno conectado a backend .NET con JWT, SQLite, Swagger y eventos.</p>
        <button onClick={login}>Login demo</button>
        <button onClick={loadTasks} disabled={!token}>Cargar tareas</button>
      </section>

      <section className="card">
        <h2>Nueva tarea</h2>
        <input placeholder="Título" value={title} onChange={e => setTitle(e.target.value)} />
        <textarea placeholder="Descripción" value={description} onChange={e => setDescription(e.target.value)} />
        <button onClick={createTask} disabled={!token || !title}>Crear</button>
      </section>

      <section className="card">
        <h2>Tareas</h2>
        {tasks.map(task => (
          <article className="task" key={task.id}>
            <strong>{task.title}</strong>
            <p>{task.description}</p>
            <small>{task.status}</small>
          </article>
        ))}
      </section>
    </main>
  );
}

createRoot(document.getElementById('root')).render(<App />);
