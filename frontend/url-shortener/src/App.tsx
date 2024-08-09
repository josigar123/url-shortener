import "./App.css";
import InputField from "./components/InputField";
import GetData from "./api/get";

function App() {
  const clickHandler = () => {
    GetData("66b25ed49823d1fafc455450");
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>URL Shortener</h1>
        <InputField />
        <h1>Test get here: </h1>
        <button onClick={clickHandler}>GET URL!</button>
      </header>
    </div>
  );
}

export default App;
