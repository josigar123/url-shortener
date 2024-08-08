import "./App.css";
import InputField from "./components/InputField";

function App() {
	const postSubmission = () => {
		console.log("Submission successful!");
	};

	return (
		<div className="App">
			<header className="App-header">
				<h1>URL Shortener</h1>
				<InputField postSubmission={postSubmission} />
			</header>
		</div>
	);
}

export default App;
