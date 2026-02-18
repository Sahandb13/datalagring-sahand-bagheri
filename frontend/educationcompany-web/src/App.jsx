import { useEffect, useState } from "react";

const API = "http://localhost:5071";

export default function App() {
    const [courses, setCourses] = useState([]);
    const [title, setTitle] = useState("");
    const [error, setError] = useState("");

    async function loadCourses() {
        try {
            const res = await fetch(`${API}/courses`);
            if (!res.ok) throw new Error("Kunde inte hämta kurser");
            const data = await res.json();
            setCourses(data);
        } catch (err) {
            setError(err.message);
        }
    }

    async function createCourse(e) {
        e.preventDefault();
        try {
            const res = await fetch(`${API}/courses`, {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({ title, description: null }),
            });

            if (!res.ok) throw new Error("Kunde inte skapa kurs");

            setTitle("");
            loadCourses();
        } catch (err) {
            setError(err.message);
        }
    }

    useEffect(() => {
        loadCourses();
    }, []);

    return (
        <div style={{ padding: 20, fontFamily: "system-ui" }}>
            <h1>EducationCompany</h1>

            <form onSubmit={createCourse} style={{ marginBottom: 20 }}>
                <input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder="Kursnamn"
                />
                <button type="submit" style={{ marginLeft: 10 }}>
                    Skapa kurs
                </button>
            </form>

            {error && <p style={{ color: "red" }}>{error}</p>}

            <h2>Kurser</h2>
            <ul>
                {courses.map((c) => (
                    <li key={c.id}>{c.title}</li>
                ))}
            </ul>
        </div>
    );
}
