// src/components/Navbar.jsx
import { Link } from "react-router-dom";

function Navbar() {
  return (
    <header
      style={{
        padding: "20px",
        backgroundColor: "#f0f0f0",
        borderBottom: "1px solid #ccc",
      }}
    >
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
