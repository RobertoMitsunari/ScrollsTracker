import { createBrowserRouter, RouterProvider } from "react-router-dom";

import Layout from "./components/Layout";
import Biblioteca from "./pages/Biblioteca";
import Home from "./pages/Home";

const router = createBrowserRouter([
  {
    element: <Layout />,
    children: [
      {
        path: "/",
        element: <Home />,
      },
      {
        path: "/biblioteca",
        element: <Biblioteca />,
      },
    ],
  },
]);

// O componente App agora é responsável por prover o roteamento para a aplicação
function App() {
  return <RouterProvider router={router} />;
}

export default App;
