import React, { Component } from 'react';
import { StyleSheet, View, Text } from 'react-native';
import { purple, white } from '../utils/colors';
import DeckItem from './DeckItem';
import { connect } from 'react-redux';

class Decks extends Component {
	renderDecks = () => {
		if (this.props.decks.length === 0) {
			return (
				<View style={styles.centered}>
					<Text style={styles.message}>You don't have any decks. Why not create one?</Text>
				</View>
			);
		} else {
			return this.props.decks.map((deck) => (
				<DeckItem
					key={deck.title}
					title={deck.title}
					noOfCards={deck.noOfCards}
					showDetail={() => this.showDetail(deck.title)}
				/>
			));
		}
	};

	showDetail = (id) => {
		this.props.navigation.navigate('DeckDetail', { id });
	};
	render() {
		return (
			<View style={styles.container}>
				<View style={styles.column}>{this.renderDecks()}</View>
			</View>
		);
	}
}

const styles = StyleSheet.create({
	container: {
		flex: 1,
		padding: 20,
		backgroundColor: white,
		justifyContent: 'flex-start'
	},
	column: {
		flexDirection: 'column',
		flex: 1
	},
	message: {
		fontSize: 20,
		justifyContent: 'center',
		alignContent: 'center',
		textAlign: 'center'
	},
	centered: {
		flex: 1,
		padding: 20,
		backgroundColor: white,
		justifyContent: 'center'
	}
});

function mapStateToProps(state) {
	const decks = [];

	for (let [ key ] of Object.entries(state)) {
		const noOfCards =
			state[key].questions ? state[key].questions.length :
			0;
		decks.push({ title: state[key].title, noOfCards });
	}

	return { decks };
}

export default connect(mapStateToProps)(Decks);
