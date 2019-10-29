import React, { Component } from 'react';
import { StyleSheet, View, Text, Button } from 'react-native';
import { purple, white } from '../utils/colors';
import { connect } from 'react-redux';
import AppButton from './AppButton';
import { HitTestResultTypes } from 'expo/build/AR';

class Quiz extends Component {
	static navigationOptions = ({ navigation }) => ({
		title: `Quzzing ${navigation.state.params.id}`,
		headerStyle: {
			backgroundColor: purple
		},
		headerTintColor: white
	});

	state = {
		currentQuestion: 0,
		showAnswer: false,
		totalCorrect: 0,
		totalIncorrect: 0,
		showResults: false
	};

	onPress = () => {
		this.setState({ showAnswer: !this.state.showAnswer });
	};

	captureAnswer = (answer) => {
		switch (answer) {
			case 'correct':
				this.setState({ totalCorrect: this.state.totalCorrect + 1 });
				break;
			case 'incorrect':
				this.setState({ totalIncorrect: this.state.totalIncorrect + 1 });
				break;
		}
		if (this.state.currentQuestion + 1 >= this.props.questions.length) {
			this.setState({ showResults: true });
			return;
		}
		this.setState({ currentQuestion: this.state.currentQuestion + 1 });
	};

	onRestart = () => {
		this.setState({
			currentQuestion: 0,
			showAnswer: false,
			totalCorrect: 0,
			totalIncorrect: 0,
			showResults: false
		});
	};
	render() {
		if (this.state.showResults) {
			return (
				<View style={styles.container}>
					<View style={{ margin: 20 }}>
						<Text style={{ fontSize: 30, textAlign: 'center' }}>
							{this.state.totalCorrect} Correct out of {this.props.questions.length}
						</Text>
					</View>
					<AppButton title="Restart Quiz" onPress={this.onRestart} />
					<AppButton title="Back to Deck" onPress={() => this.props.navigation.navigate('Decks')} />
				</View>
			);
		} else {
			return (
				<View style={styles.container}>
					<View>
						<Text style={{ fontSize: 15, textAlign: 'center' }}>
							{this.state.currentQuestion + 1} of {this.props.questions.length}
						</Text>
					</View>
					<View style={styles.contentArea}>
						<Text style={styles.contentText}>
							{
								this.state.showAnswer ? this.props.questions[this.state.currentQuestion].answer :
								this.props.questions[this.state.currentQuestion].question}
						</Text>
					</View>
					<Button
						title={

								this.state.showAnswer ? 'Show Question' :
								'Show Answer'
						}
						onPress={this.onPress}
					/>
					<AppButton title="Correct" onPress={() => this.captureAnswer('correct')} />
					<AppButton title="Incorrect" onPress={() => this.captureAnswer('incorrect')} />
				</View>
			);
		}
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		backgroundColor: white,
		justifyContent: 'flex-start'
	},
	contentText: {
		fontSize: 20,
		textAlign: 'center'
	},
	contentArea: {
		margin: 20
	}
});

function mapStateToProps(state, ownProps) {
	const id = ownProps.navigation.state.params.id;
	if (!state[id]) return { id };
	const title = state[id].title;
	return { id, title, questions: state[id].questions };
}

export default connect(mapStateToProps)(Quiz);
