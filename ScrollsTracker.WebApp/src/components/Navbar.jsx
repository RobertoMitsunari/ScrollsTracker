// src/components/Navbar.jsx
import { Link } from "react-router-dom";

function Navbar() {
  return (
    <header className="bg-orange-400 text-black p-5 border-b-4 border-indigo-500">
      <nav>
        <ul style={{ listStyle: "none", display: "flex", gap: "20px" }}>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/biblioteca">Biblioteca</Link>
          </li>
        </ul>
      </nav>
    </header>
  );
}

export default Navbar;
