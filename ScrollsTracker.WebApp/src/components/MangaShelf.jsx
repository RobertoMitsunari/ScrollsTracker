import MangaItem from "../components/MangaItem.jsx";

function MangaShelf(props) {
  const { obras } = props;
  return (
    <div>
      {obras.map((obra) => (
        <MangaItem
          titulo={obra.titulo}
          descricao={obra.descricao}
          imagem={obra.imagem}
          ultimoCapitulo={obra.totalCapitulos}
          key={obra.id}
        />
      ))}
    </div>
  );
}

export default MangaShelf;
