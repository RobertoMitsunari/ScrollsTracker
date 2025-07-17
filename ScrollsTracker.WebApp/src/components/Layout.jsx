// src/components/Layout.jsx
import React from "react";
import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";

function Layout() {
  return (
    <div>
      <Navbar />
      <main style={{ padding: "20px" }}>
        {/* O conteúdo da página específica da rota será renderizado aqui */}
        <Outlet />
      </main>
    </div>
  );
}

export default Layout;
