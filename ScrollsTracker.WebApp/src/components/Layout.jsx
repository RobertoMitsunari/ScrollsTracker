import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";

function Layout() {
  return (
    <div>
      <Navbar />
      <main className="p-4 bg-stone-900 h-screen w-screen">
        {/* O conteúdo da página específica da rota será renderizado aqui */}
        <Outlet />
      </main>
    </div>
  );
}

export default Layout;
