import React, { Component } from 'react';
import { StyleSheet, View, Text, Button } from 'react-native';
import { purple, white } from '../utils/colors';
import AppButton from './AppButton';
import { connect } from 'react-redux';
import { deleteExistingDeck } from '../actions';

class DeckDetail extends Component {
	onDeletePress = () => {
		this.props.dispatch(deleteExistingDeck(this.props.id));
		this.props.navigation.navigate('Decks');
	};

	onAddCard = () => {
		this.props.navigation.navigate('AddCard', { id: this.props.id });
	};

	onStartQuiz = () => {
		this.props.navigation.navigate('Quiz', { id: this.props.id });
	};

	render() {
		const { title, noOfCards } = this.props;
		return (
			<View style={styles.container}>
				<View>
					<Text style={styles.itemHeader}>{title}</Text>
					<Text style={styles.itemFooter}>{noOfCards}</Text>
				</View>
				<View style={{ marginBottom: 50 }}>
					<View>
						<AppButton title="Add Card" onPress={this.onAddCard} />
						<AppButton title="Start Quiz" onPress={this.onStartQuiz} />
					</View>
				</View>
				<Button title="Delete Deck" onPress={this.onDeletePress} />
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		backgroundColor: white,
		justifyContent: 'space-around'
	},
	itemHeader: {
		textAlign: 'center',
		fontSize: 40
	},
	itemFooter: {
		textAlign: 'center',
		fontSize: 30
	}
});

function mapStateToProps(state, ownProps) {
	const id = ownProps.navigation.state.params.id;
	if (!state[id]) return { id };
	const title = state[id].title;
	const noOfCards = state[id].questions.length;
	return { id, title, noOfCards };
}

export default connect(mapStateToProps)(DeckDetail);
